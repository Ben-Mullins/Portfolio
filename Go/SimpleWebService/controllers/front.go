package controllers

import (
	"encoding/json"
	"io"
	"net/http"
)

// ***Followed tutorial on Pluralsight made by Michael Van Sickle called Go: Getting Started***

// RegisterControllers handles endpoints
func RegisterControllers() {
	uc := newUserController()

	http.Handle("/users", *uc)
	http.Handle("/users/", *uc)
}

func encodeResponseAsJSON(data interface{}, w io.Writer) {
	enc := json.NewEncoder(w)
	enc.Encode(data)
}
