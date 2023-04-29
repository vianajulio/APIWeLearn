namespace APIWeLearn.Controllers {
    public static class ConnectionMySql {
        public const string connection = "server=welearndb.mariadb.database.azure.com;database=mydb;user id=welearnadmin@welearndb; password=Password?";
    }

    public static class UserSQL {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL User */
        public const string insertUser =
            "INSERT INTO usuarios(nome_usuario, email, senha, tipo_usuario, data_cadastro, pier_sit_reg)" +
            "VALUES(@name, @email, @password, @userType, @data, 'ATV')";

        public const string searchUsers = 
            "SELECT * " +
            "FROM usuarios " +
            "WHERE id_usuario = @id_usuario " +
            "AND pier_sit_reg = 'ATV' ";

        public const string editUser = 
            "UPDATE usuarios " +
            "SET nome_usuario = @userName " +
            ", senha = @userPassword " +
            ", pier_sit_reg = @pierSitReg " +
            " WHERE id_usuario = @idUser";
    }

    public static class CategorySQL {
        public const string connectiondb = ConnectionMySql.connection;

        /* Métodos SQL Category */
        public const string insertCategory = 
            "INSERT INTO categorias(nome_categoria, descricao_categoria, pier_sit_reg) " +
            "VALUES(@name, @description, 'ATV')";

        public const string searchCategory = 
            "SELECT * FROM categorias " +
            "WHERE id_categoria = @idCategory " +
            "AND pier_sit_reg = 'ATV'";
    }

    public static class ClassSQL {
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
