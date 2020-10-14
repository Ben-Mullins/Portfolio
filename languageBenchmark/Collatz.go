package main

import (
	"fmt"
	"strconv"
	"time"
	"os"
)

func main() {
	startTime := time.Now()
	count := 1
	answer := 1
	broken := false
	file, _ := os.Create("go.txt")

	for broken != true {
		for answer != 1 {
			if answer % 2 == 1 {
				answer = (answer * 3) + 1
			} else if answer <= 0 {
				fmt.Println(strconv.Itoa(count) + " solved the Collatz conjecture!")
				os.Exit(1)
			} else {
				answer = answer/2
			}
		}
		count = count + 1
		answer = count
		if count % 1000000 == 0 { // record every 1 million
			fmt.Println("Reached " + strconv.Itoa(count) + " in " + time.Now().Sub(startTime).String())
			file.WriteString(strconv.Itoa(count) + "," + time.Now().Sub(startTime).String() + "\n")
		}
	}

}
