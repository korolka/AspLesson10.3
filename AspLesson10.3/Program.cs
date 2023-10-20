//Задание
//Создайте middleware, который в случае исключений во время обработки запроса будет логировать ошибку в файл.

//Задание 1
//Установите seq и поменяйте настройки приложения из предыдущего задания, таким образом, чтобы значения записывались в seq, а не в файл.

namespace AspLesson10._3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddFile();
            builder.Logging.AddSeq();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    app.Logger.LogError($"Exception from my midlдeware:{ex.Message}");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}