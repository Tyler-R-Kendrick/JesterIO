
DistributedApplicationBuilder builder;
builder = new(new DistributedApplicationOptions() { });
await builder
    .Build()
    .RunAsync();
