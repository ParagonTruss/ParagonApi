namespace ParagonApi;

internal static class ConnectionUtilities
{
    internal static async Task<TResponse> Get<TResponse>(this HttpClient client, string url)
    {
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await DeserializeResponse<TResponse>(response);
    }

    internal static async Task Post<TRequest>(this HttpClient client, string url, TRequest requestBody)
    {
        var requestContent = CreateSerializedContent(requestBody);

        var response = await client.PostAsync(url, requestContent);
        response.EnsureSuccessStatusCode();
    }

    internal static async Task<TResponse> Post<TRequest, TResponse>(
        this HttpClient client,
        string url,
        TRequest requestBody
    )
    {
        var requestContent = CreateSerializedContent(requestBody);

        var response = await client.PostAsync(url, requestContent);
        response.EnsureSuccessStatusCode();

        return await DeserializeResponse<TResponse>(response);
    }

    internal static async Task<TResponse> PostNoContent<TResponse>(this HttpClient client, string url)
    {
        var response = await client.PostAsync(url, content: null);
        response.EnsureSuccessStatusCode();

        return await DeserializeResponse<TResponse>(response);
    }

    internal static async Task Put<TRequest>(this HttpClient client, string url, TRequest requestBody)
    {
        var requestContent = CreateSerializedContent(requestBody);

        var response = await client.PutAsync(url, requestContent);
        response.EnsureSuccessStatusCode();
    }

    internal static async Task<TResponse> Put<TRequest, TResponse>(
        this HttpClient client,
        string url,
        TRequest requestBody
    )
    {
        var requestContent = CreateSerializedContent(requestBody);

        var response = await client.PutAsync(url, requestContent);
        response.EnsureSuccessStatusCode();

        return await DeserializeResponse<TResponse>(response);
    }

    internal static async Task Patch(this HttpClient client, string url)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), url);

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    internal static async Task Patch<TRequest>(this HttpClient client, string url, TRequest requestBody)
    {
        var requestContent = CreateSerializedContent(requestBody);
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = requestContent };

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    internal static async Task<TResponse> Patch<TRequest, TResponse>(
        this HttpClient client,
        string url,
        TRequest requestBody
    )
    {
        var requestContent = CreateSerializedContent(requestBody);
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = requestContent };

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await DeserializeResponse<TResponse>(response);
    }

    internal static async Task Delete(this HttpClient client, string url)
    {
        var response = await client.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }

    private static StringContent CreateSerializedContent<TRequest>(TRequest requestBody)
    {
        var serializedBody = Serialization.Serialize(requestBody);
        return new StringContent(serializedBody, Encoding.UTF8, "application/json");
    }

    private static async Task<TResponse> DeserializeResponse<TResponse>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<TResponse>(content);
    }
}
