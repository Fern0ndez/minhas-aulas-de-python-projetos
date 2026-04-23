#  if / elif      / else
#  se / se não se / se não  
entrada = input('você quer "entrar" ou "sair"? ')

if entrada == 'entrar':
   print('Vocẽ entrou no sistema.')
elif entrada == 'sair':
    print('Você saiu do sistema.')
else:
    print('Você não digitou nem entrar e nem sair.')

print('Fim do programa.')



# if:se — isso acontecer, faça isso

# elif:senão se — testa outra condição, só se a primeira deu não.

# else:senão — tudo que sobrou, sem condição.

# resumindo:
# if:Se isso for verdade, faz X.
# elif:Se não, mas isso for verdade, faz Y.
# else:Se nada disso for verdade, faz Z.