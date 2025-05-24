using GerenciadorTarefa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefa.Application.DTOs
{
    public class DeleteTarefaDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public TarefaStatus Status { get; set; }
    }
}
