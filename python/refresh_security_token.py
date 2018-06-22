'''
.. moduleauthor:: Ben Hunter <ben.hunter@levvel.com>

'''
import sys
import os 

import boto3

keys = {
        "SecretAccessKey": "AWS_SECRET_ACCESS_KEY",
        "SessionToken": "AWS_SESSION_TOKEN",
        "AccessKeyId": "AWS_ACCESS_KEY_ID"
        }

if __name__ == "__main__":
    if "AWS_ACCESS_KEY_ID" in os.environ:
        for v in keys.values():
            del os.environ[v] 
    sts = boto3.client('sts')
    creds = sts.get_session_token(TokenCode=sys.argv[-1], 
            SerialNumber=os.environ.get('MFA_DEVICE_ARN', ''))
    cred_gen = ("export " + keys[k] + '=' + creds['Credentials'][k] for k in keys.keys())
    cred_string = '\n'.join(cred_gen)
    with open("tmp-creds.sh", "w") as f:
        f.write(cred_string)

