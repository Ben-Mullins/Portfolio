package main

import (
	"net/http"

	"github.com/Ben-Mullins/SimpleWebService/controllers"
)

// ***Followed tutorial on Pluralsight made by Michael Van Sickle called Go: Getting Started***
func main() {
	controllers.RegisterControllers()
	http.ListenAndServe(":3000", nil)
}
