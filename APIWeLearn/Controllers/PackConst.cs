namespace APIWeLearn.Controllers
{
    public static class ConnectionMySql
    {
        public const string connection = "server=localhost;database=mydb;user id=root; password=root";
    }

    public static class UserSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL User */
        public const string insertUser =
            "INSERT INTO users(userName, userEmail, userPassword, userType, userRegisterDate, userStatus)" +
            "VALUES(@name, @email, @password, @userType, @data, 'ACT')";

        public const string searchUser =
            "SELECT * " +
            "FROM users " +
            "WHERE userEmail = @email " +
            "AND userStatus = 'ACT'";

        public const string loginUser =
          "SELECT * " +
          "FROM users " +
          "WHERE userEmail = @email " +
          "AND userPassword = @password " +
          "AND userStatus = 'ACT' ";

        public const string editUser =
            "UPDATE users " +
            "SET userName = @name" +
            ", userPassword = @password " +
            ", userStatus = @userType " +
            " WHERE id_usuario = @id";
    }

    public static class CategorySQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL Category */
        public const string insertCategory =
            "INSERT INTO categorias(nome_categoria, descricao_categoria, userStatus) " +
            "VALUES(@name, @description, 'ACT')";

        public const string getAllCategory =
            "SELECT * FROM categorias " +
            "WHERE userStatus = 'ACT'";
    }

    public static class AnswersSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        public const string getAllAnswers = 
            "SELECT respostas.id_resposta" +
            ", conteudo_resposta" +
            ", data_resposta" +
            ", respostas.userStatus" +
            ", u.nome_usuario" +
            " FROM respostas " +
            " INNER JOIN users AS u ON respostas.id_usuario_resposta = u.id_usuario" +
            " INNER JOIN topicos AS t ON respostas.id_topico_resposta = t.id_topico " +
            " WHERE t.id_topico = @id_topico";

        public const string postAnswers =
            "INSERT INTO respostas ( id_topico_resposta, conteudo_resposta, id_usuario_resposta" +
            ", data_resposta, userStatus)" +
            " VALUES (@id_topico_resposta, @conteudo_resposta, @id_usuario_resposta" +
            ", @data_resposta, @userStatus)";


    }

    public static class TopicSQL

    {
        public const string connectiondb = ConnectionMySql.connection;

        public const string postTopico =
            "INSERT INTO topicos(titulo_topico, assunto_topico, data_topico" +
            ", id_categoria_topico, id_usuario_topico, id_aula_topico" +
            ", userStatus) " +
            " VALUES(@titulo_topico,@assunto_topico, @data_topico" +
            ", @id_categoria_topico, @id_usuario_topico, @id_aula_topico" +
            ", @userStatus)";

      

        public const string getTopics =
          "SELECT topicos.id_topico " +
            ", topicos.titulo_topico " +
            ", topicos.assunto_topico " +
            ", topicos.userStatus " +
            ", topicos.data_topico " +
            ", c.nome_categoria " +
            ", u.nome_usuario " +
            " FROM topicos " +
            " INNER JOIN categorias AS c ON topicos.id_categoria_topico = c.id_categoria " +
            " INNER JOIN users AS u ON topicos.id_usuario_topico = u.id_usuario " +
            " WHERE topicos.userStatus = 'ACT'";

        public const string getSelectedTopics =
           "SELECT topicos.id_topico " +
            ", topicos.titulo_topico " +
            ", topicos.assunto_topico " +
            ", topicos.userStatus " +
            ", topicos.data_topico " +
            ", c.nome_categoria " +
            ", u.nome_usuario " +
            " FROM topicos " +
            " INNER JOIN categorias AS c ON topicos.id_categoria_topico = c.id_categoria " +
            " INNER JOIN users AS u ON topicos.id_usuario_topico = u.id_usuario " +
            " WHERE c.nome_categoria = @nomeCategoria" +
            " AND topicos.userStatus = 'ACT'";

        public const string putTopicsDES =
            "UPDATE topicos SET topicos.userStatus = 'DES' WHERE topicos.id_topico = @id_topico";

        public const string delTopico = "DELETE FROM topicos WHERE topicos.id_topico = @id_topico";
    }

    public static class ClassSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL Class*/
        public const string insertClass =
            "INSERT INTO aulas (titulo_aula, descricao_aula, thumbnail_url, video_url, data_aula, id_usuario_aula, id_categoria_aula, userStatus) " +
            "VALUES (@title, @description, @thumbnail_url, @video_url, @data, @id_user_class, @id_category_class, 'ACT')";

        public const string updateClass =
            "UPDATE aulas " +
            "SET userStatus = 'DES' " +
            "WHERE id_aula = @idAula";

        public const string selectClasses =
            "SELECT cd_aula " +
            ", titulo_aula " +
            ", descricao_aula " +
            ", thumbnail_url " +
            ", video_url " +
            ", data_aula " +
            "FROM aulas " +
            "WHERE id_categoria_aula = @id_categoria_aula " +
            "AND userStatus = 'ACT'";

        public const string selectClass =
            "SELECT cd_aula " +
            ", titulo_aula " +
            ", descricao_aula " +
            ", thumbnail_url " +
            ", video_url " +
            ", data_aula " +
            "FROM aulas " +
            "WHERE cd_aula = @cd_aula " +
            "AND id_categoria_aula = @id_categoria_aula " +
            "AND userStatus = 'ACT' ";

        public const string selectClassbyCategoryandTeacher =
            "SELECT aulas.cd_aula " +
            ", aulas.titulo_aula " +
            ", aulas.descricao_aula " +
            ", aulas.thumbnail_url " +
            ", aulas.video_url " +
            ", aulas.data_aula " +
            ", catogorias.nome_catogoria " +
            ", catogorias.descricao_categoria " +
            ", users.nome_usuario " +
            ", users.email " +
            "FROM aulas " +
            "INNER JOIN users ON aulas.id_usuario_aula = users.id_usuario AND users.userStatus = 'ACT' " +
            "INNER JOIN catogorias ON catogorias.id_catogoria = aulas.id_categoria_aula AND catogorias.userStatus = 'ACT' " +
            "WHERE aulas.userStatus = 'ACT' " +
            "ORDER BY aulas.id_categoria_aula ASC";
    }
}
