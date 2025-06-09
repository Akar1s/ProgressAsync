namespace ProgressAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var progress = new Progress<int>(percent =>
            {
                Console.WriteLine($"Прогресс: {percent}%");
            });

            Console.WriteLine("Загрузка...");
            await PerformFileExtractionAsync(progress);
            Console.WriteLine("Загрузка завершена!");
        }

        static async Task PerformFileExtractionAsync(IProgress<int> progress)
        {
            const int Value = 100;
            int delay = 50;

            for (int i = 1; i <= Value; i++)
            {
                await Task.Delay(delay);

                int progressPercentage = i * 100 / Value;
                progress.Report(progressPercentage);
            }
        }
    }
}
