DOTNET = $(shell which dotnet)
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
	@$(DOTNET) restore $(PROJECT_DIR)/$(PROJECT_DIR).csproj
	@$(DOTNET) tool install --global Swashbuckle.AspNetCore.Cli
	@$(DOTNET) tool install --global Versionize

.PHONY: build
build: ## 🏗️ Build the project
	@$(DOTNET) build $(PROJECT_DIR)/$(PROJECT_DIR).csproj -o $(BUILD_DIR)

.PHONY: generate-api-spec
generate-api-spec: __install_swagger_cli ## 📝 Generate API spec using Swagger
	@$(SWAGGER_CLI) tofile --output $(shell pwd)/spec.json $(BUILD_DIR)/$(PROJECT_DIR).dll "v1"

.PHONY: __install_swagger_cli
__install_swagger_cli: ## 🛠️ Install Swagger CLI tool
	@$(DOTNET) tool install --global Swashbuckle.AspNetCore.Cli

.PHONY: clean
clean: ## 🗑️ Clean up generated files
	@rm -rf $(BUILD_DIR)
	@git rm -X -f -d
