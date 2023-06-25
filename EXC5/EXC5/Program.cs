using Aluno;
using Newtonsoft.Json;
using System.Text;

namespace H1Revisao.EXC5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write(
                "Consulta de RA\n" +
                "1 - Lista de alunos\n" +
                "2 - Adicionar Novo Alunos\n" +
                ".: "
            );
            int option = int.Parse( Console.ReadLine() );
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:3000/alunos";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    switch (option)
                    {
                        case 1:
                            var alunos = JsonConvert.DeserializeObject<List<Alunos>>(responseBody);
                            foreach (var aluno in alunos)
                            {
                                Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}, RA: {aluno.RA}");
                            }
                            break;
                        case 2:
                            Console.Write(
                                "Escreva o nome,ra e idade separados por virgula. EX:\n" +
                                "   nome,ra,idade" +
                                "\n\n.: ");
                            string[] obj =  Console.ReadLine().Split(',');
                            Alunos novoAluno = new Alunos();
                            novoAluno.Insert(obj);
                            var json = JsonConvert.SerializeObject(novoAluno);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            HttpResponseMessage promise = await client.PostAsync(url, content);
                            if (promise.IsSuccessStatusCode)
                            {
                                Console.WriteLine("Novo aluno inserido com sucesso!");
                            }
                            break;
                        default:
                            break;
                    }
                }

            }
        }
    }
}