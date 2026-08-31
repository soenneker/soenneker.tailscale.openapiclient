[![](https://img.shields.io/nuget/v/soenneker.tailscale.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.tailscale.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Tailscale.OpenApiClient

A Kiota-generated .NET client for managing Tailscale devices, users, keys, ACLs, invites, posture integrations, and webhooks.

## Installation

```bash
dotnet add package Soenneker.Tailscale.OpenApiClient
```

## Usage

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Tailscale.OpenApiClient;
using Soenneker.Tailscale.OpenApiClient.Models;

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", tailscaleApiKey);

var authentication = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authentication, httpClient: httpClient);
var tailscale = new TailscaleOpenApiClient(adapter);

ListTailnetDevices200Response? response = await tailscale.Tailnet["-"].Devices.GetAsync(
    cancellationToken: cancellationToken);
```

The `-` tailnet identifier asks Tailscale to infer the tailnet from the API token. Supply an explicit tailnet name when the operation requires one.

Keep the `HttpClient`, request adapter, and `TailscaleOpenApiClient` for reuse instead of constructing them per request. The generated API follows Tailscale's OpenAPI operation and schema names, which can change when the upstream schema is regenerated.
