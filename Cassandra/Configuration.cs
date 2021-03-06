//
//      Copyright (C) 2012 DataStax Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
namespace Cassandra
{

    /// <summary>
    ///  The configuration of the cluster. This handle setting: <ul> <li>Cassandra
    ///  binary protocol level configuration (compression).</li> <li>Connection
    ///  pooling configurations.</li> <li>low-level tcp configuration options
    ///  (tcpNoDelay, keepAlive, ...).</li> </ul>
    /// </summary>
    public class Configuration
    {

        private readonly Policies _policies;

        private readonly ProtocolOptions _protocolOptions;
        private readonly PoolingOptions _poolingOptions;
        private readonly SocketOptions _socketOptions;
        private readonly ClientOptions _clientOptions;

        private readonly IAuthProvider _authProvider;
        private readonly IAuthInfoProvider _authInfoProvider;

        internal Configuration() :
            this(new Policies(),
                 new ProtocolOptions(),
                 new PoolingOptions(),
                 new SocketOptions(),
                 new ClientOptions(),
            NoneAuthProvider.Instance,
                 null)
        {
        }

        internal Configuration(Policies policies,
                             ProtocolOptions protocolOptions,
                             PoolingOptions poolingOptions,
                             SocketOptions socketOptions,
                             ClientOptions clientOptions,
                             IAuthProvider authProvider,
                             IAuthInfoProvider authInfoProvider)
        {
            this._policies = policies;
            this._protocolOptions = protocolOptions;
            this._poolingOptions = poolingOptions;
            this._socketOptions = socketOptions;
            this._clientOptions = clientOptions;
            this._authProvider = authProvider;
            this._authInfoProvider = authInfoProvider;
        }

        /// <summary>
        ///  Gets the policies set for the cluster.
        /// </summary>
        public Policies Policies
        {
            get {return _policies;}
        }

        /// <summary>
        ///  Gets the low-level tcp configuration options used (tcpNoDelay, keepAlive, ...).
        /// </summary>
        public SocketOptions SocketOptions
        {
            get {return _socketOptions;}
        }

        /// <summary>
        ///  The Cassandra binary protocol level configuration (compression).
        /// </summary>
        /// 
        /// <returns>the protocol options.</returns>
        public ProtocolOptions ProtocolOptions
        {
             get {return _protocolOptions;}
        }

        /// <summary>
        ///  The connection pooling configuration.
        /// </summary>
        /// 
        /// <returns>the pooling options.</returns>
        public PoolingOptions PoolingOptions
        {
            get {return _poolingOptions;}
        }

        /// <summary>
        ///  The .net client additional options configuration.
        /// </summary>
        public ClientOptions ClientOptions
        {
            get { return _clientOptions; }
        }

        /// <summary>
        ///  The authentication provider used to connect to the Cassandra cluster.
        /// </summary>
        /// 
        /// <returns>the authentication provider in use.</returns>
        internal IAuthProvider AuthProvider
        // Not exposed yet on purpose
        {
            get { return _authProvider; }
        }
        /// <summary>
        ///  The authentication provider used to connect to the Cassandra cluster.
        /// </summary>
        /// 
        /// <returns>the authentication provider in use.</returns>
        internal IAuthInfoProvider AuthInfoProvider
        // Not exposed yet on purpose
        {
            get { return _authInfoProvider; }
        }

    }
}

// end namespace