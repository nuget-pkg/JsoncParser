from aesrepeat import *

ar = AES128()

print("")
list = [11, 22, 33]
encoded = ar.encode_pickle(list)
print(encoded)
decoded = ar.decode_pickle(encoded)
print(decoded)

path = 'assets/list01.txt'

with open(path, mode='w') as f:
    #f.write("\n")
    f.write(encoded)
    f.write("\n")
with open(path) as f:
    enc = f.read()
    decoded = ar.decode_pickle(enc)
    print(decoded)

mydict = {"apple":1, "orange":2, "banana":3, 0:4}
val = mydict["apple"]
print(val)
print(mydict)
encoded = ar.encode_pickle(mydict)
print(encoded)

path = 'assets/mydict.txt'

with open(path, mode='w') as f:
    #f.write("\n")
    f.write(encoded)
    f.write("\n")
with open(path) as f:
    enc = f.read()
    decoded = ar.decode_pickle(enc)
    print(decoded)
