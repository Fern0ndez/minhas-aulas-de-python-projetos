# conversão de tipos, coerção
#type convertion, typecasting, coercion
#é o ato de converter um tipo em outro
# tipos  imutáveis e primitivos:
# str, int, float, bool
print(1 + 1)
print('a' + 'b')
#o python não consegue somar int com str
#e se por entre parenteses dois numeros e por um siinal de + o programa faz a soma 
#e se por duas  letrasa e por um sinal de + o programa junta as duas letras juntas
print(int('1'), type(int('1')))
print(type(float('1') + 1))
#a conversão funciona da seguinte maneira:
#"print(tipo_desejado1(valor 1), tipo_desejado2(valor 2)))"
print(type(float('1') + 1))
print(bool(' '))
print(str(11) + 'b')
