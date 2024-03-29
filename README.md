# Multithreaded File Writer Application Documentation

## Overview
The Multithreaded File Writer is a console application developed using C# language and targeting the .NET 6 runtime. It allows users to concurrently write data to a text file using multiple threads.

## Features
- Creates a text file at location `/log/out.txt`.
- Initializes the file with the format `"0, 0, <current_time_stamp>"` on the first line.
- Launches 10 threads to append 10 lines each to the file.
- Ensures thread safety and synchronization for accessing the shared file resource.
- Writes data to the file in the format `"<line_count>, <thread_id>, <current_time_stamp>"`.
- Gracefully terminates each thread after it has written 10 lines to the file.
- Waits for all threads to complete before exiting the application.

## Usage
1. Build the application using the provided source code.
2. Execute the generated executable file.
3. Wait for the application to complete its execution.
4. Check the `/log/out.txt` file for the output data.

## Docker Support

This application comes with Docker support, allowing you to containerize and deploy it easily.


### Building the Docker Image

To build the Docker image, navigate to the root directory of the project where the Dockerfile is located and run the following command (Where 'olympus-graciela-img' is the name of the image):

```bash
docker build -t olympus-graciela-img . 
```


### Docker Hub Repository
An already built Docker image for this application is available on Docker Hub. You can pull the image using the following command:
```bash
docker pull gposadas00/olympus:latest
```
Find Image in the link below

[Img olympus-graciela-img in docker hub ](https://hub.docker.com/r/gposadas00/olympus/tags)

### Running the Docker Container
After building the Docker image, you can run a Docker container using the following command: 
(Note: The output will be stored in the 'app/log' directory within the container. You can use this location to export the content to your desired local location.)
```bash
docker run -it -v c:\junk:/app/log gposadas00/olympus:latest
```