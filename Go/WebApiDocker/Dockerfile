FROM golang:latest

RUN mkdir /build
WORKDIR /build
RUN export GO111MODULE=on
RUN go get github.com/link-to-repo/WebApiDocker
RUN cd /build && git clone https://github.com/link-to-repo/WebApiDocker.git

run cd /build/WebApiDocker/main && go build
EXPOSE 8080

ENTRYPOINT [ "/build/WebApiDocker/main"]