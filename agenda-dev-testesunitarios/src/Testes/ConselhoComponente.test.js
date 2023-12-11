import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import MyComponent from '../Componentes/ConselhoComponente';


test('Renderiza um conselho pela api toda vez que o clica se no botao', async () => {
    // conselho inicial
    const primeiroConselho = "Beba agua e chore!";
  
    // conselho secundario
    const segundoConselho = "Não compre traquinas integral";
  
    // Mock da resposta inicial da API
    const mockResponseInitial = {
      numeroDaSorte: 2,
      data: {
        slip: {
          id: 159,
          advice: primeiroConselho,
        },
      },
    };
  
    // Mock da resposta da API após o clique no botão
    const mockResponseNew = {
      numeroDaSorte: 3,
      data: {
        slip: {
          id: 160,
          advice: segundoConselho,
        },
      },
    };
  
    jest.spyOn(global, 'fetch')
      .mockResolvedValueOnce({ json: jest.fn().mockResolvedValue(mockResponseInitial) })
      .mockResolvedValueOnce({ json: jest.fn().mockResolvedValue(mockResponseNew) });
  
    render(<MyComponent />);
  
    // Verifica se o conselho inicial é renderizado
    const adviceElement = await screen.findByText(new RegExp(primeiroConselho, 'i'));
    expect(adviceElement).toBeInTheDocument();
  
    // Simula o clique no botão para obter um novo conselho
    fireEvent.click(screen.getByText(/Obter Novo Conselho/i));
  
    // Aguarda o carregamento do novo conselho
    await waitFor(() => {
      // Verifica se um novo conselho é renderizado
      const newAdviceElement = screen.getByText(new RegExp(segundoConselho, 'i'));
  
      // Verifica se a frase realmente mudou
      expect(newAdviceElement.textContent).toBe(segundoConselho);
    });
  });