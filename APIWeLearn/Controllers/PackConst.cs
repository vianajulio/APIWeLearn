namespace APIWeLearn.Controllers
{
    public static class ConnectionMySql
    {
        public const string connection = "server=dbwelearn.mariadb.database.azure.com;database=welearn;user id=adm_welearn@dbwelearn; password=Password?";
    }

    public static class UserSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL User */
        public const string insertUser =
            "INSERT INTO usuarios(nome_usuario, email, senha, tipo_usuario, data_cadastro, pier_sit_reg)" +
            "VALUES(@name, @email, @password, @userType, @data, 'ATV')";

        public const string searchUser =
            "SELECT * " +
            "FROM usuarios " +
            "WHERE email = @email " +
            "AND pier_sit_reg = 'ATV' ";

        public const string loginUser =
          "SELECT * " +
          "FROM usuarios " +
          "WHERE email = @email " +
          "AND senha = @password " +
          "AND pier_sit_reg = 'ATV' ";

        public const string editUser =
            "UPDATE usuarios " +
            "SET nome_usuario = @userName " +
            ", senha = @userPassword " +
            ", pier_sit_reg = @pierSitReg " +
            " WHERE id_usuario = @idUser";
    }

    public static class CategorySQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL Category */
        public const string insertCategory =
            "INSERT INTO categorias(nome_categoria, descricao_categoria, pier_sit_reg) " +
            "VALUES(@name, @description, 'ATV')";

        public const string getAllCategory =
            "SELECT * FROM categorias " +
            "WHERE pier_sit_reg = 'ATV'";
    }

    public static class AnswersSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        public const string getAllAnswers = 
            "SELECT respostas.id_resposta" +
            ", conteudo_resposta" +
            ", data_resposta" +
            ", respostas.pier_sit_reg" +
            ", u.nome_usuario" +
            " FROM respostas " +
            " INNER JOIN usuarios AS u ON respostas.id_usuario_resposta = u.id_usuario" +
            " INNER JOIN topicos AS t ON respostas.id_topico_resposta = t.id_topico " +
            " WHERE t.id_topico = @id_topico";

        public const string postAnswers =
            "INSERT INTO respostas ( id_topico_resposta, conteudo_resposta, id_usuario_resposta" +
            ", data_resposta, pier_sit_reg)" +
            " VALUES (@id_topico_resposta, @conteudo_resposta, @id_usuario_resposta" +
            ", @data_resposta, @pier_sit_reg)";


    }

    public static class TopicSQL

    {
        public const string connectiondb = ConnectionMySql.connection;

        public const string postTopico =
            "INSERT INTO topicos(titulo_topico, assunto_topico, data_topico" +
            ", id_categoria_topico, id_usuario_topico, id_aula_topico" +
            ", pier_sit_reg) " +
            " VALUES(@titulo_topico,@assunto_topico, @data_topico" +
            ", @id_categoria_topico, @id_usuario_topico, @id_aula_topico" +
            ", @pier_sit_reg)";

        public const string searchTopic =
          "SELECT * FROM categorias " +
          "WHERE id_topico = @idTopico " +
          "AND pier_sit_reg = 'ATV'";

        public const string getTopics =
          "SELECT topicos.id_topico " +
            ", topicos.titulo_topico " +
            ", topicos.assunto_topico " +
            ", topicos.pier_sit_reg " +
            ", topicos.data_topico " +
            ", c.nome_categoria " +
            ", u.nome_usuario " +
            " FROM topicos " +
            " INNER JOIN categorias AS c ON topicos.id_categoria_topico = c.id_categoria " +
            " INNER JOIN usuarios AS u ON topicos.id_usuario_topico = u.id_usuario " +
            " WHERE topicos.pier_sit_reg = 'ATV'";

        public const string getSelectedTopics =
           "SELECT topicos.id_topico " +
            ", topicos.titulo_topico " +
            ", topicos.assunto_topico " +
            ", topicos.pier_sit_reg " +
            ", topicos.data_topico " +
            ", c.nome_categoria " +
            ", u.nome_usuario " +
            " FROM topicos " +
            " INNER JOIN categorias AS c ON topicos.id_categoria_topico = c.id_categoria " +
            " INNER JOIN usuarios AS u ON topicos.id_usuario_topico = u.id_usuario " +
            " WHERE c.nome_categoria = @nomeCategoria;";

    }

    public static class ClassSQL
    {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL Class*/
        public const string insertClass =
            "INSERT INTO aulas (titulo_aula, descricao_aula, thumbnail_url, video_url, data_aula, id_usuario_aula, id_categoria_aula, pier_sit_reg) " +
            "VALUES (@title, @description, @thumbnail_url, @video_url, @data, @id_user_class, @id_category_class, 'ATV')";

        public const string updateClass =
            "UPDATE aulas " +
            "SET pier_sit_reg = 'DES' " +
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
            "AND pier_sit_reg = 'ATV'";

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
            "AND pier_sit_reg = 'ATV' ";

        public const string selectClassbyCategoryandTeacher =
            "SELECT aulas.cd_aula " +
            ", aulas.titulo_aula " +
            ", aulas.descricao_aula " +
            ", aulas.thumbnail_url " +
            ", aulas.video_url " +
            ", aulas.data_aula " +
            ", catogorias.nome_catogoria " +
            ", catogorias.descricao_categoria " +
            ", usuarios.nome_usuario " +
            ", usuarios.email " +
            "FROM aulas " +
            "INNER JOIN usuarios ON aulas.id_usuario_aula = usuarios.id_usuario AND usuarios.pier_sit_reg = 'ATV' " +
            "INNER JOIN catogorias ON catogorias.id_catogoria = aulas.id_categoria_aula AND catogorias.pier_sit_reg = 'ATV' " +
            "WHERE aulas.pier_sit_reg = 'ATV' " +
            "ORDER BY aulas.id_categoria_aula ASC";
    }
}
