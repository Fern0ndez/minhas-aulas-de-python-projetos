Nome = 'Gabriel Machado' 
altura = 1.70
peso = 54
imc = peso / (altura ** 2)


linha_1 = f'{Nome} tem {altura:.2f} de {altura} de altura'

print('nome:' , Nome, 'tem' , altura , 'de altura,')
print('pesa' , peso , 'quilos e seu imc é')
print(imc)

#f-strings são usadas para formatar strings de maneira mais eficiente e legível.
#e tbm permite a formatação de números, como no exemplo acima onde a altura é formatada com duas casas decimais usando :.2f dentro das chaves {}.