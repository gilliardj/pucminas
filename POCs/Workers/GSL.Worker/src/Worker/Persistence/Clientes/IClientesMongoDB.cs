namespace Worker.Persistence.Clientes
{
    public interface IClientesMongoDB
    {
        void InserirObjeto(GSL.SharedModel.Message.AdicionarClienteMessage adicionarClienteMessage);
    }
}