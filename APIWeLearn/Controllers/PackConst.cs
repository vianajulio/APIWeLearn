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
            "INSERT INTO categories(categoryNmae, categoryDescription, categoryStatus) " +
            "VALUES(@name, @description, 'ACT')";

        public const string getAllCategory =
            "SELECT * FROM categories " +
            "WHERE categoryStatus = 'ACT'";
    }

    public static class AnswersSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        public const string getAllAnswers =
            "SELECT answerID" +
            ", answerContent" +
            ", answerDate" +
            ", respostas.userStatus" +
            ", u.userName" +
            " FROM respostas " +
            " INNER JOIN users AS u ON answers.answerUserID = u.userID" +
            " INNER JOIN topics AS t ON answer.topicID = t.topicID " +
            " WHERE t.topicID = @topicID";

        public const string postAnswers =
            "INSERT INTO respostas ( topicID_resposta, conteudo_resposta, id_usuario_resposta" +
            ", data_resposta, userStatus)" +
            " VALUES (@topicID_resposta, @conteudo_resposta, @id_usuario_resposta" +
            ", @data_resposta, @userStatus)";


    }

    public static class TopicSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        public const string postTopico =
            "INSERT INTO topics(topicTitle, topicDescription, topicDate, topicCategoryID, topicUserID, topicVideoID, topicStatus) " +
            "VALUES (@topicTitle, @topicDescription, @topicDate, @topicCategoryID, @topicUserID, @topicVideoID, 'ACT')";
      
        public const string getTopics =
          "SELECT topics.topicID " +
            ", topics.topicTitle " +
            ", topics.topicContent " +
            ", topics.topicStatus " +
            ", topics.data_topico " +
            ", c.categoryName " +
            ", u.userName " +
            " FROM topics " +
            " INNER JOIN categories AS c ON topics.topicCategoryID = c.categoryID" +
            " INNER JOIN users AS u ON topics.topicUserID = u.userID " +
            " WHERE topics.topicStatus = 'ACT'";

        public const string getSelectedTopics =
           "SELECT topics.topicID " +
            ", topics.topicTitle " +
            ", topics.topicContent " +
            ", topics.userStatus " +
            ", topics.data_topico " +
            ", c.categoryName " +
            ", u.userName " +
            " FROM topics " +
            " INNER JOIN categorias AS c ON topics.id_categoria_topico = c.id_categoria " +
            " INNER JOIN users AS u ON topics.id_usuario_topico = u.id_usuario " +
            " WHERE c.categoryName = @nomeCategoria" +
            " AND topics.userStatus = 'ACT'";

        public const string putTopicsDES =
            "UPDATE topics SET topics.userStatus = 'DES' WHERE topics.topicID = @topicID";

        public const string delTopico = "DELETE FROM topics WHERE topics.topicID = @topicID";
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
            ", users.userName " +
            ", users.email " +
            "FROM aulas " +
            "INNER JOIN users ON aulas.id_usuario_aula = users.id_usuario AND users.userStatus = 'ACT' " +
            "INNER JOIN catogorias ON catogorias.id_catogoria = aulas.id_categoria_aula AND catogorias.userStatus = 'ACT' " +
            "WHERE aulas.userStatus = 'ACT' " +
            "ORDER BY aulas.id_categoria_aula ASC";
    }
}
