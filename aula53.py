import os

lista = []

while True:
    print('Selecione uma opção')
    opcao = input('[i]nserir [a]pagar [l]istar: ').lower()

    if opcao == 'i':
        os.system('clear')
        valor = input('Valor: ')
        lista.append(valor)

    elif opcao == 'a':
        indice_str = input('Escolha o índice para apagar: ')

        try:
            indice = int(indice_str)

            confirmacao = input(
                f'Tem certeza que deseja apagar "{lista[indice]}"? (s/n): '
            ).lower()

            if confirmacao == 's':
                del lista[indice]
                print('Item apagado com sucesso.')
            else:
                print('Operação cancelada.')

        except ValueError:
            print('Por favor digite número inteiro.')

        except IndexError:
            print('Índice não existe na lista.')

        except Exception:
            print('Erro desconhecido.')

    elif opcao == 'l':
        os.system('clear')

        if len(lista) == 0:
            print('Nada para listar')

        for i, valor in enumerate(lista):
            print(i, valor)

    else:
        print('Por favor, escolha i, a ou l.')