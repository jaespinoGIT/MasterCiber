from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives import hashes

hashFicheroOriginal = "944a1e869969dd8a4b64ca5e6ebc209a"
ficheroOriginal = "WinMD5.exe"
ficheroDuplicado = "WinMD5_2.exe"

print('Hash MD5 del fichero original:     ', hashFicheroOriginal)

with open(ficheroOriginal, 'rb') as f:
    data = f.read()

f.close()

digest = hashes.Hash(hashes.MD5(), backend=default_backend())

digest.update(data)

hashObtenidoFicheroOriginal=digest.finalize()

print('Hash MD5 del fichero ' + ficheroOriginal + ':   ', hashObtenidoFicheroOriginal.hex())

with open(ficheroDuplicado, 'rb') as f:
    data = f.read()

f.close()

digest = hashes.Hash(hashes.MD5(), backend=default_backend())

digest.update(data)

hashObtenidoFicheroDuplicado=digest.finalize()

print('Hash MD5 del fichero ' + ficheroDuplicado + ': ', hashObtenidoFicheroDuplicado.hex())

assert hashObtenidoFicheroOriginal.hex() == hashFicheroOriginal
assert hashObtenidoFicheroDuplicado.hex() != hashObtenidoFicheroOriginal.hex()
assert hashObtenidoFicheroDuplicado.hex() != hashFicheroOriginal