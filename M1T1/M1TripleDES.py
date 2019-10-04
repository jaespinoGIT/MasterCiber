import os
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.backends import default_backend
backend = default_backend()
key = os.urandom(24)
cipher = Cipher(algorithms.TripleDES(key), modes.ECB(), backend=backend)
encryptor = cipher.encryptor()
cryptogram = encryptor.update(b"a secret message") + encryptor.finalize()
print(cryptogram)

decryptor = cipher.decryptor()
clearText=decryptor.update(cryptogram) + decryptor.finalize()
print(clearText)