using OllamaSharp;
class Program
{
    static async Task Main(string[] args)
    {
        // Prepare o cliente Ollama API.
        var uri = new Uri("http://localhost:11434");
        var ollama = new OllamaApiClient(uri);

        // Especifique o modelo que deseja utilizar.
        ollama.SelectedModel = "llama3";

        var chat = new Chat(ollama);

        while (true)
        {
            Console.WriteLine("Pergunte qualquer coisa: ");
            var message = Console.ReadLine();

            Console.WriteLine("OLlama responde: ");
            await foreach (var answerToken in chat.SendAsync(message))
                Console.Write(answerToken);

            Console.WriteLine();
        }
    }
}
