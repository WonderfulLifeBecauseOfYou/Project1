import requests
import parsel

url = 'https://www.xiaohongshu.com/user/profile/63bcf848000000002702a482?m_source=pinpai'
# prepare camouflage   user-agent: identify label
headers = {'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:121.0) Gecko/20100101 Firefox/121.0'}
response = requests.get(url=url, headers=headers)
html = response.text

selector = parsel.Selector(html)
lis = selector.xpath('//div[@class="reds-tab-item active"]')


