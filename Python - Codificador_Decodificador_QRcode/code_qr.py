import qrcode
from qrcode import QRCode
from qrcode.image.styledpil import StyledPilImage
from qrcode.image.styles.moduledrawers import RoundedModuleDrawer
from qrcode.image.styles.moduledrawers import CircleModuleDrawer
from qrcode.image.styles.colormasks import SolidFillColorMask
from PIL import Image, ImageDraw
from datetime import datetime


def style_eyes(img):
    img_size = img.size[0]
    x = 70   # 70 default
    y = 40   # 40 default
    z = 255  # 255 default
    mask = Image.new('L', img.size, 0)
    draw = ImageDraw.Draw(mask)
    draw.rectangle((y, y, (x+y), (x+y)), fill=z)
    draw.rectangle((img_size - (x+y), y, img_size - y, (x+y)), fill=z)
    draw.rectangle((y, img_size - (x+y), (x+y), img_size - y), fill=z)
    return mask


code_qr = QRCode(error_correction=qrcode.constants.ERROR_CORRECT_H, box_size=100, border=1)
qr_info = 'dmndcode@gmail.com'
now = datetime.now()
inf_dt = now.strftime('%d%m%y%H%M%S')
code_qr.make(fit=True)

code_qr.add_data(qr_info)
qr_eyes_img = code_qr.make_image(image_factory=StyledPilImage,
                                 eye_drawer=RoundedModuleDrawer(radius_ratio=1.2),
                                 color_mask=SolidFillColorMask(back_color=(255, 255, 255), front_color=(0, 0, 0)))

qr_img = code_qr.make_image(image_factory=StyledPilImage,
                            module_drawer=RoundedModuleDrawer(),
                            color_mask=SolidFillColorMask(front_color=(0, 0, 0)),
                            embeded_image_path="Logo.png")
mask = style_eyes(qr_img)
final_img = Image.composite(qr_eyes_img, qr_img, mask)
final_img.save(f'qr{inf_dt}.png')

