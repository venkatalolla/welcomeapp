import yaml
import os
import sys

from jinja2 import Template

path = ''
if len(sys.argv) > 1:
    path = sys.argv[-1]

files = os.listdir(path)

if not os.path.exists(os.path.join(path, 'tmp')):
    os.makedirs(os.path.join(path, 'tmp'))

for fname in [y for y in files if '-template' in y and (y.endswith('yaml') or y.endswith('yml'))]:
    new_fname = fname.replace('-template', '')
    with open(os.path.join(path, fname)) as f:
        t = Template(f.read())
        with open(os.path.join(path, 'tmp', new_fname), 'w') as n:
            n.write(t.render(os.environ))

