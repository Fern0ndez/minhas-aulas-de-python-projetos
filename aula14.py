n = 'Acf'
m = 'B'
o = 1.1
string = 'a={0} b={0} c={2:.2f}'
formato = string.format(n, m, o)
print(formato)
#resumo:
#format() é um método de formatação de strings em Python que permite inserir valores em uma string usando placeholders (chaves {}) e especificar a ordem ou nome dos argumentos.
#{}=são espaços sem conteúdo que serão preenchidos com valores fornecidos ao método format().
#.format()=é o método que realiza a substituição dos placeholders pelos valores fornecidos.
