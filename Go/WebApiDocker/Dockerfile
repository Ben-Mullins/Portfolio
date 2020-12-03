FROM golang:latest

RUN mkdir /build
WORKDIR /build
RUN export GO111MODULE=on
RUN go get github.com/Ben-Mullins/Portfolio/Go/WebApiDocker
RUN cd /build && git clone https://github.com/Ben-Mullins/Portfolio.git


run cd /build/Portfolio/Go/WebApiDocker && go build main.go
EXPOSE 8080

ENTRYPOINT [ "/build/Portfolio/Go/WebApiDocker/main" ]