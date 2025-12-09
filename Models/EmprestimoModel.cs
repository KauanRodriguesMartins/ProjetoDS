    namespace ProjetoDS.Models
    {
        public class EmprestimoModel
        {
            public int Id {get; set;}
            public int LivroId {get; set;}
            public int UsuarioId {get; set;}
            public DateTime DataEmprestimo { get; set; }
            public DateTime? DataDevolucao { get; set; }
            public LivroModel Livro { get; set; }
            public UsuarioModel Usuario { get; set; }


        }
    }