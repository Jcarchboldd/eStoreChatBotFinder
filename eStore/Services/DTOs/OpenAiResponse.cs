namespace eStore;

public class OpenAiResponse
{
    public string Id { get; set; } = string.Empty;
    public int Created { get; set; }
    public Choice[] Choices { get; set; } = [];

}

public class Choice
{
    public int Index { get; set; }
    public Message Message { get; set; } = new Message();
}

public class Message
{
    public string Role { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

public class BotResponse
{
    public List<string> Product { get; set; } = new List<string>();
    public bool Is_Related_ToCategory { get; set; }
    public string Natural_Response { get; set; } = string.Empty;
    public bool Is_Related_To_Product { get; set; }
    public bool Is_Greeting { get; set; }
    public bool Is_Farewell { get; set; }
    public bool Is_Non_Relevant_Query { get; set; }
    public string Product_Available_Response { get; set; } = string.Empty;
    public string Product_Unavailable_Response { get; set; } = string.Empty;
}
