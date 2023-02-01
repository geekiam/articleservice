client.test("Successful request with OK 201", () => {

    client.assert(response.status === 201, "HTTP Response status code is not 201");
    var contentType = response.contentType.mimeType;

    client.assert(contentType === "application/json", "Expected content-type 'application/json' but received '" + contentType + "'");

    client.global.set("website_created_id", response.body.id);
});