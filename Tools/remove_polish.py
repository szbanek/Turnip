while True:
    x = input()
    x = x.replace('ć','c').replace('ł','l').replace('ą','a').replace('ó','o').replace('ż','z').replace('ź','z').replace('ń','n').replace('ś','s').replace('ę','e')
    print('\n')
    print(x)