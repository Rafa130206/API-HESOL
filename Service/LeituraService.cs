using Hesol.ModelAux;
using Hesol.Models;
using Hesol.Repository;
using Hesol.Validation;

namespace Hesol.Service
{
    public class LeituraService
    {
        private readonly LeituraRepository _repository;

        public LeituraService(LeituraRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Leitura>> GetAllLeituraAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Leitura?> GetLeituraByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }
            return await _repository.GetByIdAsync(id);
        }

        public async Task<LeituraAux> AddLeituraAsync(LeituraAux leituraAux)
        {
            LeituraValidation leituraValidation = new LeituraValidation();
            Leitura leitura = new Leitura();
            leitura = leituraValidation.Analise(leituraAux);
            await _repository.AddAsync(leitura);
            return leituraAux;
        }

        public async Task UpdateLeituraAsync(int id, LeituraAux leituraAux)
        {
            if (id != leituraAux.IdLeitura)
            {
                throw new ArgumentException("O ID na URL não corresponde ao ID da Leitura que deseja ser alterado");
            }
            LeituraValidation leituraValidation = new LeituraValidation();
            Leitura leitura = new Leitura();
            leitura = leituraValidation.Analise(leituraAux);
            await _repository.UpdateAsync(leitura);
        }

        public async Task DeleteLeituraAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("O ID não pode ser zero.");
            }

            var leitura = await _repository.GetByIdAsync(id);

            if (leitura == null)
            {
                throw new KeyNotFoundException($"ID {id} não foi encontrado no sistema");
            }

            await _repository.DeleteAsync(leitura);
        }




        
    }
}
