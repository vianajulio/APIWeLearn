using System;

namespace APIWeLearn.Models
{
    public class Forum
    {
        int? topicID;
        string? topicContent;
        DateTime? data_topico;
        int? id_categoria_topico;
        int? id_usuario;
        int? aulas_id_aula;
        int? aulas_id_usuario_aula;
        string? pier_sit_reg;

        public Forum() { }
        public Forum(int? topicID, string? topicContent, DateTime? data_topico, int? id_categoria_topico, int? id_usuario, int? aulas_id_aula, int? aulas_id_usuario_aula, string? pier_sit_reg) {
            this.topicID = topicID;
            this.topicContent = topicContent;
            this.data_topico = data_topico;
            this.id_categoria_topico = id_categoria_topico;
            this.id_usuario = id_usuario;
            this.aulas_id_aula = aulas_id_aula;
            this.aulas_id_usuario_aula = aulas_id_usuario_aula;
            this.pier_sit_reg = pier_sit_reg;     
        
        }

        internal bool InsertTopico()
        {
            return false;
        }



    }
}
