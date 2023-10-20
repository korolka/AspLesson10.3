//�������
//�������� middleware, ������� � ������ ���������� �� ����� ��������� ������� ����� ���������� ������ � ����.

//������� 1
//���������� seq � ��������� ��������� ���������� �� ����������� �������, ����� �������, ����� �������� ������������ � seq, � �� � ����.

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
                    app.Logger.LogError($"Exception from my midl�eware:{ex.Message}");
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