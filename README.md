# RedShirt.DnsUpdater

An experiment in playing with the DigitalOcean API.

## Run Script

Example run script:

```bash
#!/bin/bash

cd "$(dirname "$(readlink -f "${0}")")"

export DIGITAL_OCEAN__TOKEN=<redacted>
export DIGITAL_OCEAN__DOMAIN=foo.ca
export DOMAIN=foo.ca
./RedShirt.DnsUpdater 2> out.err
```