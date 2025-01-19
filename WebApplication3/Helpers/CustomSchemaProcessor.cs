using NJsonSchema;
using NJsonSchema.Generation;

public class CustomSchemaProcessor : ISchemaProcessor
{
    public void Process(SchemaProcessorContext context)
    {
        if (context.Type == typeof(Guid))
        {
            context.Schema.Type = JsonObjectType.String;
            context.Schema.Format = "uuid";
            context.Schema.Example = "123e4567-e89b-12d3-a456-426614174000"; // Example UUID
        }
    }
}