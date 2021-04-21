namespace kpi_lab5
{
    public class Config
    {
        public static string BASE_URL = "https://blog20210224225846.azurewebsites.net/api/";
        public static string Article_By_Id = BASE_URL + "articles/{articleId}";
        public static string Articles = BASE_URL + "articles/";
        public static string Blog_By_Id = BASE_URL + "blogs/{blogId}";
        public static string Blogs = BASE_URL + "blogs/";
        public static string Comment_By_Id = BASE_URL + "comments/{commentId}";
        public static string Comments = BASE_URL + "comments/";
        public static string Auth = BASE_URL + "auth/";
        public static string Username  = "Admin";
        public static string Password  = "admin123456";
    }
}