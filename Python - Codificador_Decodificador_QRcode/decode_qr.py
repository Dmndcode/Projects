from pyzbar.pyzbar import decode
from PIL import Image

decocdeQR = decode(Image.open('qr53.png'))
print(decocdeQR)

