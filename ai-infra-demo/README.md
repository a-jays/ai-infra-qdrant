# Qdrant + .NET Demo

This repository demonstrates how to set up and connect to **Qdrant** (a vector database) using **Docker** and a simple **.NET project**.

---

### Setup Instructions

### 1. Clone the Repository

	git clone <your-repo-url>

	cd <your-repo-folder>


### 2. Start Qdrant with Docker
We use docker-compose.yml to spin up Qdrant locally.

	docker compose up -d
	
		up -d = start containers in background (detached mode).

		This will create a Qdrant container and Docker volume for data storage.

Check running containers:

	docker ps


Stop containers when not needed:

	docker compose down

### 3. Run the .NET Project

	dotnet build
	dotnet run --project QdrantDemon

### 4. Test the Connection
	http://localhost:6333