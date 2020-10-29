package main

// Recieving messages port is 42068
// Sending messages port is 42069

import (
	"fmt"
	"math/rand"
	"net"
	//"strings"
	"time"
)

//var serverlist []server

type server struct { // Info needed for a server
	serverName			string
	maxUsers			int
	communicationPort	int
	userList			[]string
}

func random(number int) int {
	// Generate random numbers
	rand.Seed(time.Now().UTC().Unix())
	return rand.Intn(number)
}

func listen(parentServer *server) {
	// Listener for specific chat rooms.
	fmt.Println("Listening Initiated")
	fmt.Println(parentServer.communicationPort)

	addr := net.UDPAddr{
			Port: parentServer.communicationPort,
			IP:   net.ParseIP("127.0.0.1"),
		}
		listener, err := net.ListenUDP("udp", &addr)
		defer listener.Close()
		if err != nil {
			fmt.Println(err)
		}
		buffer := make([]byte, 255)

	for {
		_, caller, _ := listener.ReadFromUDP(buffer)
		fmt.Println(caller)
		fmt.Println(string(buffer))
		// Respond to all IPs in the object
		/*ln.WriteTo([]byte(ourExpectations+":"+strconv.Itoa(port)+"\n"), caller)
			if responseListener(ourExpectations, port) == true {
				return
			}*/
	}
}

/*func enterListener() {
	// Listener for clients to request to enter a chat room
	addr := net.UDPAddr{
			Port: 42069,
			IP:   net.ParseIP("127.0.0.1"),
		}
		listener, err := net.ListenUDP("udp", &addr)
		defer listener.Close()
		if err != nil {
			fmt.Println(err)
		}
		buffer := make([]byte, 255)

	for {
		_, caller, _ := listener.ReadFromUDP(buffer)

		fmt.Println(caller.String())
		//callerip := strings.Split(caller.String(),":")[0]
		command := strings.Split(string(buffer[:strLength(buffer)])," ") // separate command from name
		//fmt.Println(buffer) // broken
		//Commands are: create, join
		if len(command) > 1 {
			if command[0] == "create" {
				newServer := createServer(command[1], 5, "127.0.0.1")
				go listen(&newServer)
			} else if command[0] == "join" {
				fmt.Println("Checking servers")
				//serverlist[i].userList = append(serverlist[i].userList, callerip)
			} else if strings.Contains(strings.ToLower(string(buffer)), "list") { // broken
				fmt.Println("Current servers:")
				for i := 0; i < len(serverlist); i++ {
					fmt.Println(serverlist[i].serverName)
				}
			}
		}
		buffer = nil
		buffer = make([]byte, 255) // reset buffer
	}
}

func strLength(buffer []byte) int {
	for i := 0; i < len(buffer); i++ {
		if buffer[i] == 10 {
			return i
		}
	}
	return 255
}*/

func createServer(serverName string, max int, hostIP string) server {
	comPort := 42069//random(30000) + 1750
	connected := []string {hostIP}
	newServer := server{serverName, max, comPort, connected}
	//serverlist = append(serverlist, newServer)
	fmt.Println("Child Server Created.")

	return newServer
}

func main() {
	fmt.Println("Parent Server Started")
	newServer := createServer("Test1", 5, "127.0.0.1")
	listen(&newServer)
}
