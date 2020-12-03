FROM golang:latest

RUN mkdir /build
WORKDIR /build
RUN export GO111MODULE=on
RUN go get github.com/Ben-Mullins/Portfolio/Go/WebApiDocker/main
RUN cd /build && git clone https://github.com/Ben-Mullins/Portfolio.git


run cd /build/Portfolio/Go/WebApiDocker/main && go build
EXPOSE 8080

ENTRYPOINT [ "/build/Portfolio/Go/WebApiDocker/main/main" ]