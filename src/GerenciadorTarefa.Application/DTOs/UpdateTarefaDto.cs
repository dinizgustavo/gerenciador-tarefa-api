using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTarefa.Application.DTOs
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? CompletedAt { get; set; }
        public GerenciadorTarefa.Domain.Enums.TarefaStatus Status { get; set; }
    }
}
