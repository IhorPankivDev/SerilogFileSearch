namespace SerilogFileSearcher.Tests
{
    public static class Datainitializer
    {
        public static string[] GetFakeLog()
        {
            return new string[]
            {
                "2024-07-25 14:32:01 [INFO] User login successful: userId=1234",
                "2024-07-25 14:32:15 [WARN] Disk space low: drive C: has only 10% remaining",
                "2024-07-25 14:32:22 [ERROR] Database connection failed: Timeout expired",
                "2024-07-25 14:32:35 [DEBUG] Cache cleared: key=UserProfile:5678",
                "2024-07-25 14:33:01 [INFO] User logout successful: userId=1234",
                "2024-07-25 14:33:15 [WARN] High memory usage detected: 85% of RAM used",
                "2024-07-25 14:33:22 [ERROR] File not found: /var/log/application.log",
                "2024-07-25 14:33:35 [DEBUG] API call made: endpoint=/api/users/5678",
                "2024-07-25 14:34:01 [INFO] New user registration: userId=5678, email=user@example.com",
                "2024-07-25 14:34:15 [WARN] Deprecated API usage: endpoint=/api/old-endpoint",
                "2024-07-25 14:34:22 [ERROR] Application crash: NullReferenceException at Line 45",
                "2024-07-25 14:34:35 [DEBUG] Session started: sessionId=abcd1234",
                "2024-07-25 14:35:01 [INFO] User profile updated: userId=5678, fieldsUpdated=Email,Name",
                "2024-07-25 14:35:15 [WARN] Unusual login activity detected: multiple failed attempts critical",
                "2024-07-25 14:35:35 [DEBUG] Configuration reloaded: configVersion=2.1 critical",
                "2024-07-25 14:36:01 [INFO] Password changed: userId=5678 critical",
                "2024-07-25 14:36:22 [ERROR] Payment processing error: Insufficient funds",
                "2024-07-25 14:36:35 [DEBUG] User settings updated: userId=1234, settings=DarkMode",
                "2024-07-25 14:35:22 [ERROR critical] Email sending failed: SMTP server not reachable critical",
                "2024-07-25 14:36:15 [WARN] API rate limit exceeded: 1000 requests in 1 hour critical",
                "2024-07-25 14:36:35 [ERROR] error 404 critical",
                "2024-07-25 14:36:35 [ERROR] error 404 not found",
                "2024-07-25 14:36:35 [ERROR] error not found",
                "2024-07-25 14:37:01 [INFO] System backup completed: duration=15 minutes",
                "2024-07-25 14:37:15 [WARN] Unauthorized access attempt: ip=192.168.1.100",
                "2024-07-25 14:37:22 [ERROR] Unable to load configuration file: path=/etc/config.yaml",
                "2024-07-25 14:37:35 [DEBUG] Session expired: sessionId=abcd1234",
                "2024-07-25 14:38:01 [INFO] Service restarted: serviceName=AuthService",
                "2024-07-25 14:38:15 [WARN] Slow response time: endpoint=/api/data, time=3s",
                "2024-07-25 14:38:22 [ERROR] Missing environment variable: name=DB_PASSWORD",
                "2024-07-25 14:38:35 [DEBUG] New connection established: connectionId=xyz5678",
                "2024-07-25 14:39:01 [INFO] License key validated: key=ABC-123-XYZ",
                "2024-07-25 14:39:15 [WARN] Deprecated configuration detected: config=oldConfig",
                "2024-07-25 14:39:22 [ERROR] Memory allocation failed: size=512MB",
                "2024-07-25 14:39:35 [DEBUG] Temporary file created: path=/tmp/file123.tmp",
                "2024-07-25 14:40:01 [INFO] User subscription renewed: userId=1234, plan=Premium",
                "2024-07-25 14:40:15 [WARN] Inconsistent data found: table=Users, column=email",
                "2024-07-25 14:40:22 [ERROR] System overload: CPU usage=95%",
                "2024-07-25 14:40:35 [DEBUG] Log rotation executed: file=app.log",
                "2024-07-25 14:41:01 [INFO] Feature flag toggled: feature=NewUI, state=enabled",
                "2024-07-25 14:41:15 [WARN] Low battery warning: deviceId=abc123",
                "2024-07-25 14:41:22 [ERROR] Data corruption detected: file=/var/data.db",
                "2024-07-25 14:41:35 [DEBUG] User session terminated: userId=5678"
            };
        }
    }
}
