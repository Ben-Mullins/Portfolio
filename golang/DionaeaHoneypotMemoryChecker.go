package main

import (
    "bytes"
    "crypto/x509"
    "encoding/json"
    "encoding/pem"
    "fmt"
    "io/ioutil"
    "log"
    "net/http"
    "strconv"
    "strings"

    "github.com/mitchellh/go-homedir"
    "golang.org/x/crypto/ssh"
    "golang.org/x/crypto/ssh/terminal"
)

func decrypt(key []byte, password []byte) []byte {
    block, rest := pem.Decode(key)
    if len(rest) > 0 {
        log.Fatalf("Extra data included in key")
    }

    if x509.IsEncryptedPEMBlock(block) {
        der, err := x509.DecryptPEMBlock(block, password)
        if err != nil {
            log.Fatalf("Decrypt failed: %v", err)
        }
        return pem.EncodeToMemory(&pem.Block{Type: block.Type, Bytes: der})
    }
    return key
}

func PublicKeyFile(file string) ssh.AuthMethod {
    buffer, err := ioutil.ReadFile(file)
    if err != nil {
        return nil
    }
    usableKey := buffer
    if strings.Contains(string(buffer), "ENCRYPTED") { // If the keyfile is encrypted, prompt for it.
        fmt.Print("SSH Key Password: ") // This only happens ONCE per application run!
        passwd, _ := terminal.ReadPassword(0)
        usableKey = decrypt(buffer, passwd)
    }
    key, err := ssh.ParsePrivateKey(usableKey)
    if err != nil {
        log.Fatal("ERROR Parsing SSH key. Check and try again.")
    }

    return ssh.PublicKeys(key)
}

func runcmd(client *ssh.Client, cmd string) string {
    session, _ := client.NewSession()
    X, err := session.StdoutPipe()
    if err != nil {
        log.Fatal(err)
    }
    session.Run(cmd)
    results, _ := ioutil.ReadAll(X)
    return string(results)
}

func getMem(response string) int { // parse text and pull disk space usage
    for line := range strings.Split(response, "\n") {
        if strings.Contains(strings.Split(response, "\n")[line], "/dev/xvda1") { // if the file path on line is /dev/xvda1
            divide := strings.Split(strings.Split(response, "\n")[line], "%")
            num := divide[0][len(divide[0])-2:]
            num = strings.TrimSpace(num)
            returnNum, _ := strconv.Atoi(num)
            if returnNum == 0 {
                returnNum = 100
            }
            return returnNum
        }
    }
    return 100
}

func Send(hook string, message string) (resp bool) {
    resp = true
    data := make(map[string]string)
    data["text"] = message
    mkjson, _ := json.Marshal(data)
    _, err := http.Post(hook, "application/json", bytes.NewBuffer(mkjson))
    if err != nil {
        resp = false
    }
    return
}

func main() {
    hook := "https://google.com" // Replace with your webhook **
    keyfile, _ := homedir.Expand("/home/path/to/keyfile") // Replace with ssh key path **
    var hostlist = []string{"8.8.8.8", "21.12.21.12", "42.24.42.24", "1.1.1.1", "0.0.0.0", "123.123.123.123"}
    var location = []string{"Tokyo", "Sao Paulo", "Singapore", "Virginia", "Frankfurt", "Ireland"}
    var percentages = []int{0, 0, 0, 0, 0, 0}
    config := &ssh.ClientConfig{
        User: "admin",
        Auth: []ssh.AuthMethod{
            PublicKeyFile(keyfile),
        },
        HostKeyCallback: ssh.InsecureIgnoreHostKey(),
    }
    sendMSG := "-=[HONEYPOT DAILY REPORT]=-   \n"
    for host := range hostlist {
        client, err := ssh.Dial("tcp", hostlist[host]+":22", config)
        if err != nil {
            log.Fatal("Unable to connect.")
        }
        cmds := "df -h" // Command to run
        percentages[host] = getMem(runcmd(client, cmds))
        sendMSG = sendMSG + hostlist[host] + " (" + location[host] + ") has used " + strconv.Itoa(percentages[host]) + "% of its disk space.   \n"
    }
    Send(hook, sendMSG)
}
