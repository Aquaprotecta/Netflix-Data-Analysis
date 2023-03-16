from flask import Flask, request, jsonify
import pandas as pd
import io

app = Flask(__name__)

@app.route('/process_csv', methods=['POST'])
def process_csv():
    if 'csv_file' not in request.files:
        return 'No file uploaded', 400
    
    csv_file = request.files['csv_file']
    
    if not csv_file.filename.endswith('.csv'):
        return 'Invalid file format', 401
    
    csv_contents = csv_file.read().decode('utf-8')
    df = pd.read_csv(io.StringIO(csv_contents))
    
    columns = ['Profile Name', 'Start Time', 'Duration', 'Title']
    if not set(columns).issubset(set(df.columns)):
        return 'CSV file is missing required columns', 402
    
    df = df.drop(['Attributes', 'Supplemental Video Type', 'Device Type', 'Bookmark', 'Latest Bookmark', 'Country'], axis=1)
    df['Start Time'] = pd.to_datetime(df['Start Time'], utc=True)
    df['Duration'] = pd.to_timedelta(df['Duration'])
    df = df[(df['Duration'] > '0 days 00:01:00')]
    # df['Duration'].sum()
    
    totalTime = str(df['Duration'].sum())
    
    return totalTime
    
    

@app.route('/status', methods=['GET'])
def api_status():
    return 'API is currently online. Version: pre release.'



if __name__ == '__main__':
    app.run(debug=True)