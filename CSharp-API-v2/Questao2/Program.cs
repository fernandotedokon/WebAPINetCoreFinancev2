using Newtonsoft.Json;
using RestSharp;


public class Program
{
    public static void Main()
    {
        //        getFootballData();

        Console.Clear();
        Console.WriteLine("===============================");
        Console.WriteLine("===1 - Listar Jogo por time ===");
        Console.WriteLine("===2 - Sair do Sistema      ===");
        Console.WriteLine("===============================");
        Console.WriteLine();
        Console.Write("Digite a opção desejada: ");

        var opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("===============================");
                Console.WriteLine();
                getFootballData();
                break;
            default:
                Console.WriteLine("Opcao incorreta.");
                break;
        }
    }


    public static void getFootballData()
    {
        var client = new RestClient("https://jsonmock.hackerrank.com/api/");

        //var client = new RestClient("https://jsonmock.hackerrank.com/api/football_matches?year=2015&team1=Galatasaray");

        Console.Write("Digite o nome do time 1: ");
        string teamName1 = Console.ReadLine();

        Console.Write("Digite o ano do time 1: ");
        int year1 = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.Write("Digite o nome do time 2: ");
        string teamName2 = Console.ReadLine();

        Console.Write("Digite o ano do time 2: ");
        int year2 = int.Parse(Console.ReadLine());


        if (!string.IsNullOrEmpty(teamName1) && year1 > 0)
        {
            var request = new RestRequest("football_matches?" + "year=" + year1 + "&" + "team1=" + teamName1);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawresponse = response.Content;

                Questao2.Futebol result = JsonConvert.DeserializeObject<Questao2.Futebol>(rawresponse);


                int gol, goals = 0;

                foreach (var item in result.data)
                {
                    if (item.Team1 == teamName1)
                    {
                        if ((int)item.Team1Goals > 0)
                        {
                            gol = ((int)item.Team1Goals);
                            goals += gol;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("==============================================================================");
                Console.WriteLine("Team 1: " + teamName1 + " scored " + goals + " goals in " + year1);
                Console.WriteLine("==============================================================================");
            }
        }
        else Console.WriteLine("Team 1 não foi informado ");


        if (!string.IsNullOrEmpty(teamName2) && year2 > 0)
        {
            var request = new RestRequest("football_matches?" + "year=" + year2 + "&" + "team2=" + teamName2);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawresponse = response.Content;

                Questao2.Futebol result = JsonConvert.DeserializeObject<Questao2.Futebol>(rawresponse);


                int gol, goals = 0;

                foreach (var item in result.data)
                {
                    if (item.Team2 == teamName2)
                    {
                        if ((int)item.Team2Goals > 0)
                        {
                            gol = ((int)item.Team2Goals);
                            goals += gol;
                        }
                    }
                }

                Console.WriteLine("Team 2: " + teamName2 + " scored " + goals + " goals in " + year2);
                Console.WriteLine("==============================================================================");
            }
        }
        else Console.WriteLine("Team 2 não foi informado ");



        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();



    }

}