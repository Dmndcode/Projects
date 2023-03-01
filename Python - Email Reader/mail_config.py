import imaplib
import email
from datetime import datetime
from base import user, password
from email.header import decode_header
from email.utils import parsedate_to_datetime
from email.policy import default
from bs4 import BeautifulSoup
from sys import exit

imap_server = "imap.gmail.com"  # account credentials
email_address = user  # User - account credentials
pw = password  # Password - account credentials

imap = imaplib.IMAP4_SSL(imap_server, port=993, timeout=3)  # IMAP server of the mail provider
imap.login(email_address, pw)  # Imap + User credentials

typ, data = imap.select("Inbox")  # Here we select Inbox, from mail.
# To see the inbox ("Inbox")
# if you want see SPAM, use ("[Gmail]/Spam") instead
num_msgs = int(data[0])  # Email quantity counter
if num_msgs > 1:
    print('Mensagens não lidas: %d 📬.' % num_msgs)
elif num_msgs == 1:
    print('Mensagem não lida: %d 📬.' % num_msgs)
elif num_msgs < 1:
    print('Quantidade: %d, 📭🥳️ Parabéns! Você leu todas as mensagens...' % num_msgs)

resp_code, mail_ids = imap.search('utf-8', 'All')
# search for specific mails by sender 'FROM "example@google.com"
# to get mails by subject 'SUBJECT "Hey! Your order #0001 has been delivered!"
# to get mails after a specific date 'SINCE "11-NOV-2022"
# to get mails before a specific date 'BEFORE "01-JAN-2020"
# to get all mails "ALL"
list_email = []
list_from = []

decode_header('=?iso-8859-1?q?p=F6stal?=')
for mail_id in mail_ids[0].decode().split()[-num_msgs:]:  # convert messages to a list of email IDs
    # let's iterate over targeted mails
    print("⌜﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉ ✅ Início do email✉ [{}] ✅ ﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉﹉⌝".format(mail_id))

    resp_code, mail_data = imap.fetch(mail_id, '(RFC822)')  # Fetch mail data.

    message = email.message_from_bytes(mail_data[0][1], policy=default)  # Construct Message from mail data
    de = message.get('From')
    print(f"︴De       : {de}")
    print(f"︴Para     : {message.get('To')}")
    print(f"︴CC       : {message.get('Bcc')}")
    mail_date_time_str = message.get("Date")
    local_time_str = datetime.fromtimestamp(parsedate_to_datetime(mail_date_time_str).timestamp()).strftime(
        '%d/%m/%Y %H:%M:%S')
    print(f"︴Data     : {local_time_str}")
    subject, encoding = decode_header(message.get('Subject'))[0]
    if encoding is not None:
        # if it's a bytes, decode to str
        subject = subject.decode(encoding)
        print(f"︴Assunto  : {subject}")
    elif encoding is None:
        print(f"︴Assunto  : {subject}")

    # read the body of the email
    for part in message.walk():
        if part.get_content_maintype() == 'text':
            try:
                body = part.get_payload(decode=True)
                soup = BeautifulSoup(body, 'html.parser').get_text()
                soup.encode('utf-8', 'ignore').decode('utf-8')
                parameters = soup.split()
                print('︴➥➥➥: ' + ' '.join(parameters[0:25]))
            except Exception:
                body = part.get_payload()
                soup = body
                soup.encode('ASCII', 'ignore').decode('ASCII')
                parameters = soup.split()
                print('︴➥➥➥: ' + ' '.join(parameters[0:25]))
        else:
            pass

    print("⌞﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎ 🔚 Fim do email✉ [{}] 🔚 ﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎⌟\n".format(mail_id))

    imap.expunge()
    list_email.append(mail_id)
    list_from.append(de)

if num_msgs == 0:
    exit(1)
else:
    for sender in range(len(list_from)):
        a = list_email[sender]
        b = list_from[sender]
        print(f"⌜﹉﹉﹉﹉﹉﹉  ✉ Email 🟢 [{b}] ﹉﹉﹉﹉﹉﹉﹉⌝")
        w = input(f"Deletar 🔶🔶🔶️:\nSim [S]\nNão [N]\n>: ").lower()
        if w == 's':
            imap.store(f"{a}", "+FLAGS", '\\Deleted')
            print(f"")
            print(f"⌞﹎﹎﹎ 🟥 Mensagem de: {b}, ❌ excluída.  ﹎﹎﹎⌟\n")
        elif w == 'n':
            imap.store(a, '+X-GM-LABELS', 'Visto')
            print("⌞﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎ 🟩 Mensagem adicionada a categoria: |visto| ﹎﹎﹎﹎﹎﹎﹎﹎﹎﹎⌟\n")
