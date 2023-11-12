DOTNET = "dotnet"
SWAGGER_CLI = ~/.dotnet/tools/swagger
PROJECT_DIR = WebAPI
BUILD_DIR = ./build

.DEFAULT_GOAL := help
.PHONY: help
help:
	@echo "Available targets:"
	@awk -F':|##' \
		'/^[^\t].+?:.*?##/ && !/^[[:space:]]*__/{\
			printf "\033[36m%-30s\033[0m %s\n", $$1, $$NF \
		}' $(MAKEFILE_LIST)

.PHONY: install
install: ## 🛠️ Restore dependencies
	@dotnet restore $(PROJECT_DIR)/$(PROJECT_DIR).csproj
	@dotnet tool install --global Versionize

.PHONY: build
build: ## 🏗️ Build the project
	@dotnet build $(PROJECT_DIR)/$(PROJECT_DIR).csproj -o $(BUILD_DIR)

.PHONY: generate-api-spec
generate-api-spec: __install_swagger_cli ## 📝 Generate API spec using Swagger
	@$(SWAGGER_CLI) tofile --output $(shell pwd)/spec.json $(BUILD_DIR)/$(PROJECT_DIR).dll "v1"

.PHONY: __install_swagger_cli
__install_swagger_cli: ## 🛠️ Install Swagger CLI tool
	@dotnet tool install --global Swashbuckle.AspNetCore.Cli

.PHONY: clean
clean: ## 🗑️ Clean up generated files
	@rm -rf $(BUILD_DIR)
	@git clean -X -f -d

.PHONY: test
test: ## 🧪 Run tests
	@dotnet test
