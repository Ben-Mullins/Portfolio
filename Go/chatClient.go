package main

// Recieving messages port is 42068
// Sending messages port is 42069

import (
	"fmt"
	//"net"
)

func getInput() {
	var userInput string
	fmt.Scanln(&userInput)
	fmt.Println(userInput)
	return
}

func main() {
	var name string

	fmt.Print("Enter your name: ")
	fmt.Scanln(&name)
	fmt.Println("Welcome " + name + ". Joining server...")
	go getInput()
	

}