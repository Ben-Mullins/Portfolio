Run these commands in the same directory as the docker file

docker build -t golangwebapi .
docker run -p 8080:8080 -tid golangwebapi